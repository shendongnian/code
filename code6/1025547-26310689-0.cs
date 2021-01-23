        using System.Windows.Forms;
        class MyApplicationContext : ApplicationContext
        {
            private void onFormClosed(object sender, EventArgs e)
            {
                Application.Exit();
            }
      
            public MyApplicationContext()
            {
                //If WinForms exposed a global event that fires whenever a new Form is created,
                //we could use that event to register for the form's `FormClosed` event.
                //Without such a global event, we have to register each Form when it is created
                var forms = new List<Form>() {
                new Form1(),
                 new Form2(),
                 };
                foreach (var form in forms)
                {
                    form.FormClosed += onFormClosed;
                    form.Show();
                }
            }
        }
