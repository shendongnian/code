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
            protected override void Generate(System.Data.Entity.Migrations.Model.AddPrimaryKeyOperation addPrimaryKeyOperation)
            {
                addPrimaryKeyOperation.Table = _GetNameWithReplacedSchema(addPrimaryKeyOperation.Table);
                base.Generate(addPrimaryKeyOperation);
            }
            protected override void Generate(System.Data.Entity.Migrations.Model.AlterColumnOperation alterColumnOperation)
            {
                string tableName = _GetNameWithReplacedSchema(alterColumnOperation.Table);
                var newAlterColumnOperation = new System.Data.Entity.Migrations.Model.AlterColumnOperation(tableName, alterColumnOperation.Column, alterColumnOperation.IsDestructiveChange);
                base.Generate(newAlterColumnOperation);
            }
            protected override void Generate(System.Data.Entity.Migrations.Model.DropPrimaryKeyOperation dropPrimaryKeyOperation)
            {
                dropPrimaryKeyOperation.Table = _GetNameWithReplacedSchema(dropPrimaryKeyOperation.Table);
                base.Generate(dropPrimaryKeyOperation);
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
            protected override void Generate(System.Data.Entity.Migrations.Model.RenameTableOperation renameTableOperation)
            {
                string oldName = _GetNameWithReplacedSchema(renameTableOperation.Name);
                string newName = renameTableOperation.NewName.Split(new char[] { '.' }).Last();
                var newRenameTableOperation = new System.Data.Entity.Migrations.Model.RenameTableOperation(oldName, newName, renameTableOperation.AnonymousArguments);
                base.Generate(newRenameTableOperation);
            }
            protected override void Generate(System.Data.Entity.Migrations.Model.RenameIndexOperation renameIndexOperation)
            {
                string tableName = _GetNameWithReplacedSchema(renameIndexOperation.Table);
                var newRenameIndexOperation = new System.Data.Entity.Migrations.Model.RenameIndexOperation(tableName, renameIndexOperation.Name, renameIndexOperation.NewName);
                base.Generate(newRenameIndexOperation);
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
            protected override void Generate(System.Data.Entity.Migrations.Model.RenameColumnOperation renameColumnOperation)
            {
                string newTableName = _GetNameWithReplacedSchema(renameColumnOperation.Table);
                var newRenameColumnOperation = new System.Data.Entity.Migrations.Model.RenameColumnOperation(newTableName, renameColumnOperation.Name, renameColumnOperation.NewName);
                base.Generate(newRenameColumnOperation);
            }
            protected override void Generate(System.Data.Entity.Migrations.Model.DropTableOperation dropTableOperation)
            {
                string newTableName = _GetNameWithReplacedSchema(dropTableOperation.Name);
                var newDropTableOperation = new System.Data.Entity.Migrations.Model.DropTableOperation(newTableName, dropTableOperation.AnonymousArguments);
                base.Generate(newDropTableOperation);
            }
            protected override void Generate(System.Data.Entity.Migrations.Model.DropForeignKeyOperation dropForeignKeyOperation)
            {
                dropForeignKeyOperation.PrincipalTable = _GetNameWithReplacedSchema(dropForeignKeyOperation.PrincipalTable);
                dropForeignKeyOperation.DependentTable = _GetNameWithReplacedSchema(dropForeignKeyOperation.DependentTable);
                base.Generate(dropForeignKeyOperation);
            }
            protected override void Generate(System.Data.Entity.Migrations.Model.DropIndexOperation dropIndexOperation)
            {
                dropIndexOperation.Table = _GetNameWithReplacedSchema(dropIndexOperation.Table);
                base.Generate(dropIndexOperation);
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
