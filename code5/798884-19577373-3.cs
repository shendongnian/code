    <script runat="server">
        public string URL
        {
            get
            {
                // TODO insert the user's fields here
                return CreateUrl(FirstName, LastName, ...);
            }
        }
    </script>
    <a href='<%= URL %>'>Login</a>
