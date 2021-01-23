    public void Page_Load()
    {
        if (!string.IsNullOrEmpty(hdnSubmissionID.Value))
        {
            SessionHelper.Set(SessionKey.SubmissionId, hdnSubmissionID.Value);
            lnkBtnPrint.HRef = PublisherConfigurationManager.Navigation + "Printable_Submission_Document.aspx");
        }
    }
