    //
    // btnOk
    //
    Name = "btnOk";
    Text = "&Ok";
    btnOk.Click += new System.EventHandler(this.btnOk_Click);
    //
    // btnCancel
    //
    DialogResult = System.Windows.Forms.DialogResult.Cancel;
    Name = "btnCancel";
    Text = "&Cancel";
    btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    //
    // txtUserName
    //
    Name = "txtUserName";
    //
    // txtPassword
    //
    PasswordChar = '*';
    Name = "txtPassword";
    //
    // label1
    //
    Name = "label1";
    Text = "Username";
    //
    // label2
    //
    Name = "label2";
    Text = "Password";
    //
    // LogoPictureBox
    //
    LogoPictureBox.Name = "LogoPictureBox";
    LogoPictureBox.TabStop = false;
    //
    // LoginForm1
    //
    AcceptButton = this.btnOk;
    CancelButton = this.btnCancel;
    ControlBox = false;
    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    Name = "LoginForm1";
    ShowInTaskbar = false;
    StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
    Text = "Login Form";
    			
