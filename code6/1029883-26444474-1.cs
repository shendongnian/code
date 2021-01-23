    public class MyApplicationContext : ApplicationContext
    {
        public MyApplicationContext(Form mainForm)
            :base(mainForm)
        {
        }
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (Form.ActiveForm != null)
            {
               this.MainForm = Form.ActiveForm;
            }
            else
            {
               base.OnMainFormClosed(sender, e);
            }
        }
    }
