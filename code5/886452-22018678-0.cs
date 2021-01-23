        if (txtResponse != null && !String.IsNullOrWhiteSpace(txtResponse.Text))
         {
              responses.Add(new QuestionnaireUserAnswer()
              {
                    questionId = questionId,
                    answerId = 5,
                    freeText = txtResponse.Text
              });
         }
