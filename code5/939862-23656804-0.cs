    class Company {
      public virtual int Id { get;set;}
      public virtual string Name { get;set;}
      public virtual int? IntProp { get;set;}
    }
    <syscache2>
        <cacheRegion name="RefData"></cacheRegion>
        <cacheRegion name="Company">
            <dependencies>
                <commands>
                    <add name="CompanyCommand"
                             command="SELECT Id, Name, IntProp FROM dbo.Companies WHERE Deleted = 0"
            />
                </commands>
            </dependencies>
        </cacheRegion>
    </syscache2>
