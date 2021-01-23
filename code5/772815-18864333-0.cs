    bool RfcEqualsAfd=rfc.All(q=>
                             afd.Any(a=>
                                    q.Response==a.Correct && 
                                    q.AnswerId==a.AnswerId
                                    )
                             );
