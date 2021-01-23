    public IEnumerable<Button> GetAllButtons(Form form){
      Stack<Control> controls = new Stack<Control>();
      controls.Push(form);
      while(controls.Count > 0){
        var control = controls.Pop();
        foreach(var c in control.Controls){
          if(c is Button) yield return c;
          controls.Push(c);
        }
      }
    }
    //now use that method in your code like this:
    private void combo_Theme_SelectedValueChanged(object sender, EventArgs e)
    {
        Main f1 = new Main();
        if (combo_Theme.Text == "Purple")
        {
            foreach (var form in Application.OpenForms.Cast<Form>())
            {
                form.Icon = Properties.Resources.Purple;
                f1.btn_Exit.Image = Properties.Resources.EXIT_purple;
                //looping through each button on the current form
                foreach(var button in GetAllButtons(form)){
                  //your code here
                  button.Image = Properties.Resources.EXIT_purple;
                }
            }
        }
        //...
    }
    
