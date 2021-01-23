                //deserialize json
                ResponsesList responses = JsonConvert.DeserializeObject<ResponsesList>(_ResponseContent);
                if (responses != null)
                {
                    //loop through responses
                    foreach (ResponsesList.Data data in responses.data)
                        if (data != null)
                        {
                            foreach (ResponsesList.Questions question in data.questions)
                                if (question != null)
                                {
                                    foreach (ResponsesList.Answer answer in question.answers)
                                    {
                                        //upsert each response
                                        UpsertResponse(survey_id, data.respondent_id, question.question_id, answer.row, answer.col);
                                    }
                                }
                        }
                }
