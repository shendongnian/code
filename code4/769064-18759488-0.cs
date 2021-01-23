    public class ControlValidationInfo
    {
        public Control Control { get; set; }
        public string EmptyTextErrorMessage { get; set; }
    }
    ControlValidationInfo[] infos = new []{ new ControlValidationInfo{ Control = txtSrcUserID, EmptyTextErrorMessage  = "Please enter Source User_ID"}}; // add all in this array
    foreach(var info in infos)
    {
        if(String.IsNullOrEmpty(info.Control.Text))
        {
            errorProvider1.SetError(info.Control , info.EmptyTextErrorMessage);
            return; 
        }
    }
