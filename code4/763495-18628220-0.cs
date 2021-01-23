    **//MainPage.xaml.**
    private async void imgBookImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        //It is the way to take the id from the listView if you are showing your listView through Wrapper using ObservableCollection.
    	myWrapper bookName = (myWrapper)this.listCloudBooks.SelectedItem;
    	IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
     	string dir = "/MainFolder/SubFolder/" + bookName.Id;
	    if (isf.DirectoryExists(dir))
        {
        	NavigationService.Navigate(new Uri("/MainPage.xaml?selectedItem=" +bookName.Id, UriKind.Relative));//bookName.Id fetching Id of book and through bookid we will get the id on our destination page and will show the data.
        }
        else
        {	
		//In this method i am creating folder of bookId and storing into the destination folder in my          isolated storage. I am not showing the code of this method because i am answering of this question only.
	 	DownloadBooks(bookName);
	}
}
       //SecondPage.xaml
       private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
       {
	     string selectedBookId = "";//Set this variable globally.
             position = 1;
             IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
             string dir = "/MainFolder/SubFolder/" + selectedBookId;
             string concatBookJson = string.Concat(dir, "/pageRecords.json");//Taking pageRecords.json, my this file have records of my *.html pages so it is showing from isolateStorage 
             if (isf.FileExists(concatBookJson))
             {
        	    CurrentBook = GetBookContents(concatBookJson);//Returning the Json Deserialize data from the isolated storage.
                   txtBookName.Text = CurrentBook.Title;//I have title property you can access all properties of your wrapper class (myWrapper).
               
	     }
       }
