    [Fact]
    public void Some_Test_In_Need_Of_A_Mocked_Repository()
    {
       var ctx = new UnitTestContext();
    
       SubmissionVersion.DeleteNote(ctx.Repo.Object, subVersion.Object, note.Id.Value);
    }
