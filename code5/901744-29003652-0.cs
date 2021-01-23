        /// <summary>
        /// Clears rows from the TableRowCollection starting from the specified Start index
        /// </summary>
        /// <param name="Rows">The TableRowCollection</param>
        /// <param name="Start">Start Index</param>
        public static void ClearFrom(this WebControls.TableRowCollection Rows, int Start)
        {
            if (Start == 0)
            {
                Rows.Clear();
            }
            else if (Start >= Rows.Count)
            {
                return;
            }
            else
            {
                for (int i = Start; i < Rows.Count; i++)
                {
                    Rows.RemoveAt(i);
                }
            }
        }
