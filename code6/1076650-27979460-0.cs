    namespace RetrogamesWeb.Data.Services
    {
        using System.Collections.Generic;
     
        using Entities;
        using MongoDB.Bson;
        using MongoDB.Driver;
        using MongoDB.Driver.Builders;
     
        public class PlayerService: EntityService<Player>
        {
            public void AddScore(string playerId, Score score)
            {
                var playerObjectId = new ObjectId(playerId);
     
                var updateResult = this.MongoConnectionHandler.MongoCollection.Update(
                        Query<Player>.EQ(p => p.Id, playerObjectId), 
                        Update<Player>.Push(p => p.Scores, score),
                        new MongoUpdateOptions
                        {
                            WriteConcern = WriteConcern.Acknowledged
                        });
     
                if (updateResult.DocumentsAffected == 0)
                {
                    //// Something went wrong
                     
                }
            }
     
            public IEnumerable<Player> GetPlayersDetails(int limit, int skip)
            {
                var playersCursor = this.MongoConnectionHandler.MongoCollection.FindAllAs<Player>()
                    .SetSortOrder(SortBy<Player>.Ascending(p => p.Name))
                    .SetLimit(limit)
                    .SetSkip(skip)
                    .SetFields(Fields<Player>.Include(p => p.Id, p => p.Name));
                return playersCursor;
            }
     
            public override void Update(Player entity)
            {
                var updateResult = this.MongoConnectionHandler.MongoCollection.Update(
                        Query<Player>.EQ(p => p.Id, entity.Id),
                        Update<Player>.Set(p => p.Name, entity.Name)
                            .Set(p => p.Gender, entity.Gender),
                        new MongoUpdateOptions
                        {
                            WriteConcern = WriteConcern.Acknowledged
                        });
     
                if (updateResult.DocumentsAffected == 0)
                {
                    //// Something went wrong
     
                }
            }
        }
    }
