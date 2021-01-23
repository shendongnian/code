    public class QuestionForm
    {
      // skipped constructor and controls
      public static int ShowQuestion(string q, string a1, string a2,string a3,int correct)
      {
        QuestionForm f = new QuestionForm();
        f.qtnlabel.Text = q;
        f.radbtnans1.Text = a1;
        f.radbtnans2.Text = a2;
        f.radbtnans3.Text = a3;
        f.ShowDialog(owner);
        if (f.radbtnans1.Checked)
          return 0;
        else if (f.radbtnans2.Checked)
          return 1;
        else if (f.radbtnans3.Checked)
          return 2;
      }
    }
