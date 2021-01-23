            private bool IsSimpleProperty( string propertyName, DbEntityEntry entry )
            {
                DbMemberEntry memberEntry = entry.Member( propertyName );
    
                return memberEntry is DbPropertyEntry;
            }
