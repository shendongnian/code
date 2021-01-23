    ParseUser currentUser = ParseUser.getCurrentUser();
    
    currentUser.fetchInBackground(new GetCallback<ParseObject>() {
        public void done(ParseObject object, ParseException e) {
            if (e == null) {
                ParseUser currUser = (ParseUser) object;
                // Do Stuff with currUSer
            } else {
                // Failure!
            }
        }
    });
