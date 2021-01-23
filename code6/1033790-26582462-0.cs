    List<List<string>> _DataCollection=new List<List<string>>();
                _DataCollection.Add( new List<string> {"tom", "abc", "$525.34", "$123"});
    
                _DataCollection.Add( new List<string> {"dick", "xyz", "$100", "$234"});
                _DataCollection.Add( new List<string> {"harry", "", "$250.01", "$40"});
                _DataCollection.Add( new List<string> {"bob", "", "$250.01", ""});
    
                List<string> newSumList = new List<string>();
    
                for (int i = 0; i < _DataCollection.Count; i++)
                {
                    decimal Sum = 0;
                    string CurrentSumList;
                    string Comment;
                    decimal amount = 0;
                    for (int j = 0; j < _DataCollection.Count; j++)
                    {
                        bool IsDecimalAmount=decimal.TryParse( _DataCollection[j][i].Replace('$','0'),out amount);
                        if (IsDecimalAmount)
                        {
    
                            Sum += amount;
                        }
                        else
                        {
                            Comment = "String";
    
                        }
                    }
                    CurrentSumList = Sum.ToString();
                    newSumList.Add(CurrentSumList);
                }
