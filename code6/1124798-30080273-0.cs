        public override void Up()
        {
            AddColumn("myDb.BookOrders", "DailyCount", c => c.Int(nullable: false));
            Sql(string.Format(@"                
                        CREATE PROCEDURE [myDb].[DailyCountIncrement]
                        AS
                        BEGIN
	                        DECLARE @DCountPlusOne int
	                        SET @DCountPlusOne .....More SQL code here to read and increment count goes here
	                        SELECT @DCountPlusOne 
                        END"));
        }
        
        public override void Down()
        {
            DropColumn("myDb.BookOrders", "DailyCount");
            DropStoredProcedure("myDb.DailyCountIncrement");
        }
