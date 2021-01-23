    public interface IConvertableModel<TDto>
    {
        public TDto ToDto();
        public ??? SetFromDto(TDto dto);
    }
