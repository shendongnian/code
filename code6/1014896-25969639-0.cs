    private void mnuSentenize_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                frmNotepad SNTZ = (frmNotepad)ActiveMdiChild;
                string Input = ((frmNotepad)ActiveMdiChild).FileContent.ToString();
                var Result = Regex.Replace(Input, @"((?<=(?:^|\.)\s*)\p{Ll}|[.]\b[a-z]|[.] \b[a-z]|[?]\b[a-z]|[?] \b[a-z]|[!]\b[a-z]|[!] \b[a-z])", X => X.Value.ToUpper());
                SNTZ.FileContent = Result.ToString();
            }
        }
