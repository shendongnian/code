    using Newtonsoft.Json;
    ...
    void mBtnSignIn_Click(object sender,EventArgs e)
    {
          User user = new User();
          user.Name = "John";
          user.Password = "password";
          Intent intent = new Intent(this,typeof(Activity2));
          intent.PutExtra("User",JsonConvert.SerializeObject(user));
          this.StartActivity(intent);
          this.Finish();
          
    }
