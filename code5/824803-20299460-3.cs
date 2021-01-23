    public async void MyButtonClick(sender, e){
      using (var p = await preparePosition()){
        ...
      }
    }
