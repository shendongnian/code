                    // iterate through the respondents. If search query not like results throw the result away.
                    List<Respondent> toRemove = new List<Respondent>();
                    for (int i = 0; i < respondents.Count; i++)
                    {
                        if (!respondents[i].EmailAddresses.Any())
                            toRemove.Add(i);
                        else
                        {
                            bool checkSingleEmail = false;
                            bool checkAllEmails = false;
                            for (int j = 0; j < respondents[i].EmailAddresses.Count; j++)
                            {
                                checkSingleEmail = respondents[i].EmailAddresses[j].Address.ToString().Contains(query);
                                if (checkSingleEmail == true)
                                    checkAllEmails = true;
                                if (respondents[i].EmailAddresses.Count == 1 && j == 0 && checkAllEmails == false)
                                    toRemove.Add(respondents[i]);
                                else if (checkAllEmails == false && j+1 == respondents[i].EmailAddresses.Count)
                                    toRemove.Add(respondents[i]);
                            }
                        }
                    }
                    foreach (var respRemove in toRemove)
                    {
                        respondents.Remove(respRemove);
                    }
