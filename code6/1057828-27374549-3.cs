    Dim input As String = IO.File.ReadAllText("C:\Users\SARVESH\Desktop\abc.txt")
    Dim stp As New Diagnostics.Stopwatch
    stp.Start()
    input = input.Replace(" ", ",").Trim()
    While input.Contains(",,")
    	input = input.Replace(",,", ",")
    End While
    stp.Stop()
    MessageBox.Show(stp.ElapsedMilliseconds)
    
    input = IO.File.ReadAllText("C:\Users\SARVESH\Desktop\abc.txt")
    stp.Reset()
    stp.Restart()
    input = System.Text.RegularExpressions.Regex.Replace(input.Trim(" "c, ","c), "(?<=\b\w+\b)[\s,]+", ",")
    stp.Stop()
    MessageBox.Show(stp.ElapsedMilliseconds)
    
    input = IO.File.ReadAllText("C:\Users\SARVESH\Desktop\abc.txt")
    stp.Reset()
    stp.Restart()
    Dim parts As String() = input.Split({" "c, ","c}, StringSplitOptions.RemoveEmptyEntries)
    Dim result As String = String.Join(",", parts)
    stp.Stop()
    MessageBox.Show(stp.ElapsedMilliseconds)
