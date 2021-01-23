    public partial class FindAndReplaceForm : Form
    {
        public delegate void OnFindText(string txtToFind);
        public OnFindText FindText;
    
        private void btnFind_Click(object sender, EventArgs e)
        {
            if(FindText != null)
               FindText(textToSearchFor);
        }
    }
