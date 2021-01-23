    string s = txtTelefon.Text;
    string[] nums = s.Split('-');
    int counter = 0;
    IEnumerable<string> first = new List<string> { "070", "071", "072", "075", "076", "077", "078" };
    foreach (string num in nums)
    {
        if (num.Length != 3)
        {
            lblRezultat.Text = "Invalid number.";
            break;
        }
        else if (counter==0)
        {
            if (!first.Contains(num))
            {
                // first 3 digits don't match pattern
                break;
            }
        }
        else 
        {
            int try = 0;
            if (!int.TryParse(num, try))
            {
                 // not a 3 digit number
                 break;
            }
        }
        counter++
    }
    if (counter != 3)
    {
        // wrong number of splits (111-222-333-444)
    }
