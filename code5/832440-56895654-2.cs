// In MyCmdlet.cs
public class MyStateInfo {
  public string Username { get; set;}
  public string DbName { get; set;}
}
protected abstract class MyCmdlet : PSCmdlet {
    private const string StateName = "_Blah";
    protected MyStateInfo getState()
    {
        if ( ! SessionState.PSVariable.GetValue(StateName, null) is MyStateInfo s))
            SessionState.PSVariable.Set(StateName, s = new MyStateInfo());
        return s;
    }
}
At this point all your cmdlets should inherit from `MyCmdlet`, and `getState()` will always return an existing or new variable: changes to the class persist in that same session.
There are probably lots of ways to integrate this in your overall cmdlet parameter design, and this is still kinda new to me so I'm not sure if it's a best practice, but I've solved it by creating a helper cmdlet to set the initial values:
[Cmdlet(VerbsCommon.Set, "MyUsername")]
public class Set_MyUsername : MyCmdlet {
  [Parameter(Mandatory = true, Position = 1)] 
  public string Username {get; set; }
  protected override void ProcessRecord()
  {
       base.ProcessRecord();
       WriteVerbose($"Saving {Username} in session state");
       getState().Username = Username;
  }
}
Then some later cmdlet needs to do something with that:
[Cmdlet(VerbsCommunication.Connect, "Database")]
public class Connect_Database : MyCmdlet {
    [Parameter(Mandatory = false)]
    public string Username { get; set; }
    // other parameters here
    protected override void BeginProcessing()
    {
        base.BeginProcessing();
        if (Username == null)
            Username = getState().Username;
        if (Username == null)
        { // ERROR HERE: missing username }
    }
    // more stuff
}
Then, your `Connect-Database` will take an explicit `-Username steve` parameter (not consulting or touching session state), but without that parameter it pulls it from your session state object.  If the username is still missing after this, it fails (probably by `ThrowTerminatingError`).
Your `Select-Project` could work the same way.
I usually provide a `Get-MyState` cmdlet that just writes the state object to the pipeline output, mainly for debugging.  You're not limited to just one variable if your application warrants separating these things.
