    <script runat="server">
        public string URL
        {
            get
            {
                return CreateUrl(FirstName, LastName, ...);
            }
        }
    </script>
    <a href='<%= URL %>'>Login</a>
