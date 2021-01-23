    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Xml.Serialization;
    namespace Arbitrary.Parties.Moves
    {
        [XmlType("MoveList")]
        [XmlInclude(typeof(Move))]
    public class MoveList : IEnumerable<Move>
    {
        [XmlArrayItem(typeof(Move))]
        public List<Move> oMoveList = new List<Move>();
        public MoveList()
        {
        }
        public void Add(Move move)
        {
            this.oMoveList.Add(move); 
        }
        public int Count()
        {
            return oMoveList.Count;
        }
        public IEnumerator<Move> GetEnumerator()
        {
            return oMoveList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    }
