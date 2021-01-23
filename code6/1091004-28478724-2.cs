    public interface IAuditable
    {
      Guid RowGUID { get; }
      Guid InsertUserGUID { get; }
      Guid  UpdateUserGUID { get; }
      Guid DeleteUserGUID { get; }
      DateTime UpdateDate { get; }
      DateTime InsertDate { get; }
      DateTime DeleteDate { get; }
    }
