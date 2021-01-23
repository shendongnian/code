	public IEnumerable<MyJoinedEntity> GetEntities() {
		var joinedEntities = from myEntity in dbContext.MyEntities
			join myOtherEntity in dbContext.MyOtherEntities on myEntity.Id equals myOtherEntity.MyEntityId
			join oneMoreEntity in dbContext.OneMoreEntities on myEntity.Id equals oneMoreEntity.MyEntityId
				select new MyJoinedEntity {
					Id = myEntity.Id,
					Name = myEntity.Name,
					OtherProperty = myOtherEntity.OtherProperty,
					OneMoreProperty = oneMoreEntity.OneMoreProperty
				};
		
		if (condition1) {
			joinedEntities = JoinWithRelated(joinedEntities);
		}
	}
		    
	public IEnumerable<MyJoinedEntity> JoinWithRelated(IEnumerable<MyJoinedEntity> joinedEntities) {
		return from joinedEntity in joinedEntities
		join relatedEntity in dbContext.RelatedEntities on joinedEntity.Id equals relatedEntity.MyEntityId
			select new MyJoinedEntity(joinedEntity) {
				Comments = relatedEntity.Comments
			};
	}
		    
