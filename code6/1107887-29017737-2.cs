    public class QuestionForm
    {
      // skipped constructor and controls
      public int ShowQuestion(Form owner=null)
      {
        this.ShowDialog(owner);
        if (radbtnans1.Checked)
          return 0;
        else if (radbtnans2.Checked)
          return 1;
        else if (radbtnans3.Checked)
          return 2;
      }
    }
