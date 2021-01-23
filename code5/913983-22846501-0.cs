    string wild_name = "my cat likes dogs";
    string test_string = "That's my cat. He really likes black dogs";
    string[] wildStrings = wild_name.Split(' ');
    int lastFoundIndex = 0;
    bool success = true;
    for (int i = 0; i < wildStrings.Length; i++)
    {
       if (test_string.Split(' ').Contains(wildStrings[i])
       {
          int findIndex = test_string.Split(' ').IndexOf(wildStrings[i]);
          if (findIndex < lastFoundIndex)
          {
             success = false;
             break;
          }
       }
       else
       {
           success = false;
           break;
       }
    }
    
    return success;
