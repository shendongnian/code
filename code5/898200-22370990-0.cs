    public interface IDataClassesDataContext
    {
      tblBook_Sel_BasedOnbookIDResult tblBook_Sel_BasedOnBookID(int bookid);
    }
    public partial class DataClassesDataContext:IDataClassesDataContext
    {
    }
    public class Class1
    {
      IDataClassesDataContext _context;
      public Class1(IDataClassesDataContext context)
      {
        _context = context;
      }
      public List<BookList> GetBookList(int bookid)
      {
      
        List<BookList> _BookList = new List<BookList>();
       //Consider if some wcf call is there then how we can develop unit test
        using (_context)
        {
          foreach (tblBook_Sel_BasedOnbookIDResult _tblBook_selResult in _context.tblBook_Sel_BasedOnBookID(bookid))
            {
                BookList _bookListObject = new BookList();
                //Setting the proerty here
                _BookList.Add(_bookListObject);
            }
        }
        return _BookList;
     }
    }
