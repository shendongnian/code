        [Test]
        public void CustomMapping()
        {
            //arrange
            Mapper.CreateMap<Source, Destination>()
                .ForMember(d=>d.Value, opt=>opt.ResolveUsing(ResolveValue));
            Mapper.CreateMap<SourceDataType, DestinationDataType>();
            var source = new Source { Value = new SourceDataType() };
            //act
            var destination = Mapper.Map<Source, Destination>(source);
            //assert
            destination.Value.Should().Be.OfType<DestinationDataType>();
        }
        private object ResolveValue(ResolutionResult result)
        {
            var source = result.Context.SourceValue as Source;
            
            if (result.Context.IsSourceValueNull || source == null || !(source.Value is SourceDataType))
            {
                return null;
            }
            var sourceValue = source.Value as SourceDataType;
            
            return result.Context.Engine.Map<DestinationDataType>(sourceValue);
        }
