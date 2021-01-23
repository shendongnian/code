    public class CyclesLookup : BaseLookup<BaseLookupEntity>
    {
        // Fields & Constructor
        private readonly CYCLES _dOOdad;
        public CyclesLookup(IDbConnection connection, string library)
        {
            _dOOdad = OpenConnection(connection, library);
        }
        // Base Override Methods
        public override IEnumerable<BaseLookupEntity> Read()
        {
            // Clear old result set and settings
            _dOOdad.FlushData();
            // Reload the records and return them sorted and translated
            return base.ReloadRecords(
                _dOOdad.LoadAll,
                () =>
                {
                    _dOOdad.Sort = _dOOdad.GetAutoKeyColumn();
                },
                () =>
                {
                    var entity = new LookupEntity();
                    entity.Description = string.Format("Cycles for {0}", _dOOdad.YEAR);
                    return entity.PopulateLookupEntity(_dOOdad.CurrentRow.ItemArray, true);
                },
                _dOOdad.MoveNext);
        }
        // Private Helper Methods
        private static CYCLES OpenConnection(IDbConnection connection, string library)
        {
            var dOOdad = new CYCLES(connection);
            dOOdad.SchemaGlobal = library + ".";
            return dOOdad;
        }
    }
