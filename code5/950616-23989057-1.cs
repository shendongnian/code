    protected void Page_Load(object sender, EventArgs e)
        {            
            ICollection<MessageDTO> list = new List<MessageDTO>();
            for (int i = 0; i < 10; i++)
            {
                var obj = new MessageDTO() { UserId = i, DateCreated = DateTime.Now, Content = i.ToString(), ChatRoomId = 1, MessageId = i };
                list.Add(obj);
            }
            MyCustomStringProp = JsonConvert.SerializeObject(list);
        }
        public string MyCustomStringProp { get; set; }
