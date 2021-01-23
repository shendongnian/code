        public User()
        {
            // ...
            Image = new LocalFile(
                "userpic.css",
                fileName => Shared.LocalFileUrlResolver(fileName, userId)
            );
        }
