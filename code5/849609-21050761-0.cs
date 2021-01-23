    protected void RepeaterItemEventHandler(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList questionsRadioButtonList = (RadioButtonList)e.Item.FindControl("QuestionsList");
                ExamQuestion exam = (ExamQuestion)e.Item.DataItem);
                if (!String.IsNullOrEmpty(exam.exm_AnswerA))
                {
                    ListItem item = new ListItem();
                    item.Text = exam.exm_AnswerA;
                    item.Value = "A";
                    questionsRadioButtonList.Items.Add(item);
                }
                
                //the rest of the list items for the radiobuttonlist...
                var answers = (List<UserAnswer>)(Session["AnswersList"]);
                if (answers.FindIndex(a => a.QuestionID == exam.exm_ID.ToString()) > -1)
                {
                    questionsRadioButtonList.SelectedValue = 
                    answers.Find(a => a.exm_QuestionID == exam.exm_ID.ToString()).exm_UserAnswer;
                }
            }
        }
