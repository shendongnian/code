    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
      base.OnActivityResult(requestCode, resultCode, data);
      if (resultCode == Result.Ok) {
         // Do whatever needs to be done in A 
      }
    }
