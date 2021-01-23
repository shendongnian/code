    Scenario: demo
    Given ...
    When do something
    
    [Binding]
    public class Demo{
    
     [When(@"do something"), Scope(Scenario = "demo")]
     public void DoSomething(){
      {  }
    }
    
    Scenario: demo 2
    Given ...
    When do something
    ...
    
    [Binding}
    public class Demo2{
    
     [When(@"do something"), Scope(Scenario = "demo 2"))]
     public void DoSomething(){
     {  }
    
    }
