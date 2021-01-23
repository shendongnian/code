    using System;
    using System.Collections.Generic;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TenantDatabaseManager
    {
        public class SqlServerSchemaAwareMigrationSqlGenerator : SqlServerMigrationSqlGenerator
        {
            private string _schema;
    
            public SqlServerSchemaAwareMigrationSqlGenerator(string schema)
            {
                _schema = schema;
            }
    
            protected override void Generate(System.Data.Entity.Migrations.Model.AddColumnOperation addColumnOperation)
            {
                string newTableName = _GetNameWithReplacedSchema(addColumnOperation.Table);
                var newAddColumnOperation = new System.Data.Entity.Migrations.Model.AddColumnOperation(newTableName, addColumnOperation.Column, addColumnOperation.AnonymousArguments);
                base.Generate(newAddColumnOperation);
            }
    
            protected override void Generate(System.Data.Entity.Migrations.Model.CreateIndexOperation createIndexOperation)
            {
                string name = _GetNameWithReplacedSchema(createIndexOperation.Table);
    
                createIndexOperation.Table = name;
    
                base.Generate(createIndexOperation);
            }
    
            protected override void Generate(System.Data.Entity.Migrations.Model.CreateTableOperation createTableOperation)
            {
                string newTableName = _GetNameWithReplacedSchema(createTableOperation.Name);
                var newCreateTableOperation = new System.Data.Entity.Migrations.Model.CreateTableOperation(newTableName, createTableOperation.AnonymousArguments);
                newCreateTableOperation.PrimaryKey = createTableOperation.PrimaryKey;
                foreach (var column in createTableOperation.Columns)
                {
                    newCreateTableOperation.Columns.Add(column);
                }
    
                base.Generate(newCreateTableOperation);
            }
    
            protected override void Generate(System.Data.Entity.Migrations.Model.AddForeignKeyOperation addForeignKeyOperation)
            {
                addForeignKeyOperation.DependentTable = _GetNameWithReplacedSchema(addForeignKeyOperation.DependentTable);
                addForeignKeyOperation.PrincipalTable = _GetNameWithReplacedSchema(addForeignKeyOperation.PrincipalTable);
                base.Generate(addForeignKeyOperation);
            }
    
            protected override void Generate(System.Data.Entity.Migrations.Model.DropColumnOperation dropColumnOperation)
            {
                string newTableName = _GetNameWithReplacedSchema(dropColumnOperation.Table);
                var newDropColumnOperation = new System.Data.Entity.Migrations.Model.DropColumnOperation(newTableName, dropColumnOperation.Name, dropColumnOperation.AnonymousArguments);
                base.Generate(newDropColumnOperation);
            }
    
            protected override void Generate(System.Data.Entity.Migrations.Model.DropTableOperation dropTableOperation)
            {
                string newTableName = _GetNameWithReplacedSchema(dropTableOperation.Name);
                var newDropTableOperation = new System.Data.Entity.Migrations.Model.CreateTableOperation(newTableName, dropTableOperation.AnonymousArguments);
                base.Generate(newDropTableOperation);
            }
    
            private string _GetNameWithReplacedSchema(string name)
            {
                string[] nameParts = name.Split('.');
                string newName;
    
                switch (nameParts.Length)
                {
                    case 1:
                        newName = string.Format("{0}.{1}", _schema, nameParts[0]);
                        break;
    
                    case 2:
                        newName = string.Format("{0}.{1}", _schema, nameParts[1]);
                        break;
    
                    case 3:
                        newName = string.Format("{0}.{1}.{2}", _schema, nameParts[1], nameParts[2]);
                        break;
    
                    default:
                        throw new NotSupportedException();
                }
    
                return newName;
            }
        }
    }
