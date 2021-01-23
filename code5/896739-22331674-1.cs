        MyPage mypage = new MyPage();
    
        if (mypage.ShouldLoad)
        {
            mmypage.Show();
        }
        else
        {
            MeBox.Show("You have no open trades.", "", MessageBoxButton.OK, 
                       MessageBoxImage.Error);
        }
