    string[] read_Items = new string[15];
    string text = "val1  val2"
    int item_cnt = 0;
    // set delimiter for a single space  
    char[] delimiters = new char[] { ' ' };
    // Remove and double spaces and replace them with single spaces
     while (test.Contains("  "))
        test = test.Replace("  ", " ");
    // Break up line into individual items
    foreach (string word in test.Split(delimiters))
    {
        read_Items[item_cnt] = word;
        item_cnt++;
        if (item_cnt > 14)
            break;
     }
