    public interface IModelConverter<TDto, TModel>
    {
        public TDto ToDto(TModel model);
        public TModel FromDto(TDto dto);
    }
    public class DisplayEditModelConverter : IConvertBetween<DisplayEdit, DisplayModel>
    {
        ...
    }
