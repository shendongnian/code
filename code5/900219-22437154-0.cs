        public string[] Attachments
        {
            get
            {
                return mDS.Attachment.Where(row => row.RowState!= DataRowState.Deleted).Select(row2=>row2.Path).ToArray();
            }
        }
