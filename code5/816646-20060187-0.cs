    void Page_Load(...) {
       if (DateTime.Now > StartDate && DateTime.Now < EndDate) {
          MessageHolder.Controls.Add(...);
       }
    }
