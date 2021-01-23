    private void dialer_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPage.DialerText = dialer.Text;
            if(!bw1.IsBusy)
            bw1.RunWorkerAsync(listobj);
         }
     void bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var digitMap = new Dictionary<int, string>() {
        { 1, "" },
        { 2, "[abcABC]" },
        { 3, "[defDEF]" },
        { 4, "[ghiGHI]" },
        { 5, "[jklJKL]" },
        { 6, "[mnoMNO]" },
        { 7, "[pqrsPQRS]" },
        { 8, "[tuvTUV]" },
        { 9, "[wxyzWXYZ]" },
        { 0, "" },
    };
                var enteredDigits = DialerText;
                var charsAsInts = enteredDigits.ToCharArray().Select(x => int.Parse(x.ToString()));
                var regexBuilder = new StringBuilder();
    
                foreach (var val in charsAsInts)
                regexBuilder.Append(digitMap[val]);
                MainPage.pattern = regexBuilder.ToString();
    
                MainPage.pattern = ".*" + MainPage.pattern + ".*";
    
                var listobj = (ListObjectType)e.Argument;
                SearchListbox.ItemsSource = listobj.FindAll(x => x.PhoneNumbers.Any(a=>a.Contains(MainPage.DialerText)) | Regex.IsMatch(x.FirstName, MainPage.pattern));
            }
            catch (Exception f)
            {
                //  MessageBox.Show(f.Message);
            }
    
        }
    void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
