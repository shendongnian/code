    <providers>
      ...
      <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6"/>
    </providers>
    <system.data>
        <DbProviderFactories>
            <remove invariant="System.Data.SQLite.EF6" />
            <add name="SQLite Data Provider" invariant="System.Data.SQLite" description="Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
        </DbProviderFactories>
    </system.data>
