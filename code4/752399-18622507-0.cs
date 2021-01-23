    public class MyMapper:PetaPoco.IMapper{
        private PetaPoco.StandardMapper standardMapper=new PetaPoco.StandardMapper();
        public PetaPoco.TableInfo GetTableInfo(Type pocoType){
            return standardMapper.GetTableInfo(pocoType);
        }
        public PetaPoco.ColumnInfo GetColumnInfo(PropertyInfo pocoProperty){
            return standardMapper.GetColumnInfo(pocoProperty);
        }
        public Func<object, object> GetFromDbConverter(PropertyInfo TargetProperty, Type SourceType){
            if(TargetProperty.PropertyType==typeof(HStore)){
                return (x)=>HStore.Create((string)x);
            }
            return standardMapper.GetFromDbConverter(TargetProperty,SourceType);
        }
        public Func<object, object> GetToDbConverter(PropertyInfo SourceProperty){
            if(SourceProperty.PropertyType==typeof(HStore)){
                return (x)=>((HStore)x).ToSqlString();
            }
            return standardMapper.GetToDbConverter(SourceProperty);
        }
    }
