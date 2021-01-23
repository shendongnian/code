using System.Data.Entity;
namespace Portal.Repositories
{
  public class UploadRepository : IUploadRepository
  {
    public Upload Get(
      Expression&lt;Func&lt;Upload, bool>> predicate, 
      params Expression&lt;Func&lt;Upload, object>>[] includeExpressions)
    {
      var uploads = m_context.Uploads;
      foreach (var i in includeExpressions)
        uploads.Include(i);
      return uploads.FirstOrDefault(predicate);
    }
  }
}
<Upload/code>
