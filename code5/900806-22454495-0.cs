    public class SomePage
    {
        private string SelectedStatus { get; set; }
        protected void DD_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedStatus = this.DD_Status.SelectedValue.ToString();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DD_Status.SelectedValue = SelectedStatus;
        }
        // other code in the code-behind class
    }
