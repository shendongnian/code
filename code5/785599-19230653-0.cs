    public class MyTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {          
                case (Keys.Return):
                  /*
                   * Your Code to handle the event
                   * 
                   */                   
                    return;  //Not calling base method, to stop 'ding'
            }
                                 
            base.OnKeyDown(e);
        }
    }
