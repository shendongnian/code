    public interface IWidgetRepository
    {
        Widget GetById(string id);
        IEnumerable<Widget> GetAll();
    }
