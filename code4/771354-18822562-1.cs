    using(var form = new Form2()
    {
         if(DialogResult.OK == form.ShowDialog(this))
         {
              //OK was clicked, do something with the form's properties 
              // or textboxes if public
              string s = form.Textbox1Text;
         }
    }
