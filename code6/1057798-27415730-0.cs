    var dbContext = new UserDbContext();
    RuleFor(ud => ud.Email)
        .NotNull()
        .SetValidator(
            new UniquePropertyValidator<UserDetails>
             (ud, ud => ud.Email, () => dbcontext.userDetails)
        .WithMessage("This Email id has already been registered");
    public class UniquePropertyValidator<T>{
        public UniquePropertyValidator(T entity, Func<string> propertyAccessorFunc, Func<IEnumerable<T>> collectionAccessorFunc){
            _entity = entity;
            _propertyAccessorFunc =  propertyAccessorFunc;
            _collectionAccessorFunc =collectionAccessorFunc;
        }
        public bool Validate(){
           var entities = _collectionAccessorFunc();
           var propertyValue = _propertyAccessorFunc(_entity);
           var matchingEntity = entities.SingleOrDefault(e => _propertyAccessorFunc(e) == propertyValue );
           return matchingEntity ==null;
        }
    } 
