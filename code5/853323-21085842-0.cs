    public class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            switch ((WindowsMessage)m.Msg)
            {
                case WindowsMessage.WM_KEYDOWN:
                case WindowsMessage.WM_SYSKEYDOWN:
                    {
                        if (((int)m.WParam | ((int)Control.ModifierKeys)) != 0)
                        {
                            Keys keyData = (Keys)(int)m.WParam;
    
                            var activeForm = Form.ActiveForm;
                            var forms = Application.OpenForms.Cast<Form>().Where(x => x.Visible).ToArray();
                            int active = Array.IndexOf(forms, activeForm);
                            if (keyData == Keys.A)
                            {
                                int next = (active + 1)%forms.Length;
                                forms[next].Activate();//Activate next
                            }
                            else if (keyData == Keys.B)
                            {
                                int prev = (active - 1) % forms.Length;
                                forms[prev].Activate();//Activate previous
                            }
                           
                        break;
                    }
            }
    
            return false;
        }
    }
    class MainForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            Application.AddMessageFilter(new MessageFilter());
        }
    }
