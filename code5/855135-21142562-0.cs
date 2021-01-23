        private void IncrementLikes_Click(object sender, RoutedEventArgs e)
        {
            //where Likes is your ObservableCollection keeping data from database
            LikeItem oneAndOnly = Likes.First() as LikeItem;
            //you pulled one and only LikeItem object, now you increment the likes count
            oneAndOnly.LikesCount += 1;
            //and here you tell the database that the changes need to be saved.
            //This call can be delayed to the OnNavigatedFrom event,
            //  depending on your needs.
            LikeDB.SubmitChanges();
        }
