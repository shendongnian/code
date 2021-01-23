    public class CreateEnvelopeModel : ICreateEnvelopeCommand
    {
        [JsonConverter(typeof(EntityModelConverter<CreateEmailModel, ICreateEmailCommand>))]
        public ICreateEmailCommand Email { get; set; }
        [JsonConverter(typeof(CollectionEntityConverter<CreateFormModel, ICreateFormCommand>))]
        public IList<ICreateFormCommand> Forms { get; set; }
    }
