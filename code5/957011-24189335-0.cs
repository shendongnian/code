    public ActionResult openSampleView(string submissionId)
    {
        if (submissionId == null) return null;
        var model = new Models.WorkFlowTest {SubmissionId = submissionId};
        return View("Submission", model);
    }
