    class NewForm {
    
        public event EventHandler<ListT> ListUpdated;
        public NewForm(ListT in) {
            ...
        }
        private void btn_DeleteSelected_Clicked(...) {
            ListT updated = new ListT();
            foreach (var item in bindingList) {
                if (!item.Selected) {
                    updated.Add(item);
                }
            }
            ListUpdated.Invoke(this, updated);
        }
    }
